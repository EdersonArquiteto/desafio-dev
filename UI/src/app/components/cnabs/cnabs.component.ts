import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CnabService } from 'src/Services/cnab.service';

@Component({
  selector: 'app-cnabs',
  templateUrl: './cnabs.component.html',
  styleUrls: ['./cnabs.component.css']
})
export class CnabsComponent implements OnInit{
  
  expenses: any[] = [];
  currentFile: File | null = null; 
  selectedFile: File | null = null;
  progress: number = 0;
  totalPorLoja: any[]=[];
  lojas: string []=['BAR DO JOÃO','ALOJA DO Ó - MATRIZ','AMERCADO DA AVENIDA','ALOJA DO Ó - FILIAL','MERCEARIA 3 IRMÃOS'];
  total : number =0;
  formUpload: FormGroup = new FormGroup({
    file: new FormControl(null, Validators.required)
  }); 

  constructor(
    private service: CnabService
  ){}

  ngOnInit() {
    this.loadItens();
  }

  loadItens(){
    this.service.getAllItens().subscribe({
      next: (data) =>{        
        
        
        let items:any = [];

        this.expenses = data;
       
         
        for(var i=0; i<this.lojas.length;i++){
           for(var j=0; j<this.expenses.length; j++){
                if(this.lojas[i]== this.expenses[j].storeName){
                    if(this.expenses[j].tipoOcorrencia=='Aluguel' || this.expenses[j].tipoOcorrencia=='Boleto' || this.expenses[j].tipoOcorrencia=='Financiamento')
                    {
                      this.total -= this.expenses[j].value;
                    }else{
                      this.total += this.expenses[j].value;
                    }
                }
                
            }  
            this.totalPorLoja.push(this.total);
        }
       console.log(this.totalPorLoja);
        
      }
    })
  }

  onFileSelected(event: any) {
    this.currentFile = event.target.files[0];
  }

  carregar(){
    if (!this.currentFile) {
      return;
    }

    this.service.uploadFiles(this.currentFile).subscribe({
      next: (data)=>{
        if(data.type === HttpEventType.UploadProgress){
          this.progress = Math.round((100 * data.loaded) / data.total);
        }else if(data instanceof HttpResponse){
          console.log('Upload completo:');
          this.loadItens();
        }
      }
    })
  }
}
