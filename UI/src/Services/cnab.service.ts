import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})

export class CnabService {
    constructor(
        private http: HttpClient
    ){}

    getAllItens(): Observable<any>{
        return this.http.get(`${environment.APIURL}UploadFile/LoadData`)
    }

    uploadFiles(file: File): Observable<any>{
        const formData: FormData = new FormData();
        formData.append('file', file);
        return this.http.post(`${environment.APIURL}UploadFile/UploadFile`, formData, {
            reportProgress: true,
            observe: 'events'
        })
    }
}