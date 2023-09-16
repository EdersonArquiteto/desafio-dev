import { Component } from '@angular/core';
import { AutenticarHelper } from 'src/helpers/autenticar.helper';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(
    private helper: AutenticarHelper
  ){}

  sair(){
    this.helper.singOut();
  }
}
