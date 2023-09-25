import { Injectable } from "@angular/core";
import { MatSnackBar } from '@angular/material/snack-bar';

 @Injectable({providedIn: 'root'})
 export class NotifyService {
    constructor(private readonly snackBar: MatSnackBar) {}

    public success(message: string) {
      this.openSnackBar(message, '', 'success-snackbar');
    }

    public error(message: string) {
      this.openSnackBar(message, '', 'error-snackbar');
    }

      openSnackBar(
         message: string,
         action: string,
         className = '',
         duration = 3000
       ) {
         this.snackBar.open(message, action, {
           duration: duration,
           panelClass: [className]
         });
       }
 } 