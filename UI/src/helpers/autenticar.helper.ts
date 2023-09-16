import { Injectable } from "@angular/core";
import { AutenticarResponse } from "../Models/AutenticarResponse"

@Injectable({
    providedIn: 'root'
})
export class AutenticarHelper {

    /*
        método para receber os dados do usuário
        autenticado e grava-los em local storage
    */
    signIn(response: AutenticarResponse): void {
        const data = JSON.stringify(response);
        localStorage.setItem('auth_usuario', data);
    }

    singOut(){
        localStorage.removeItem('auth_usuario');
        location.href = "/"
    }
}
