import {Component, OnInit} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.scss']
})
export class SupportComponent implements OnInit {
  text = '';

  constructor(private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
  }

  click() {
    this.snackBar.open('Дякуємо за звернення', 'ОК', {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
      panelClass: ['my-snack'],
      politeness: 'assertive'
    });
    this.text = ' ';
    // @ts-ignore
    document.getElementById('exampleFormControlTextarea1').value = '';
  }
}
