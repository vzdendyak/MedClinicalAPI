import {Component, OnInit} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  burgerActive: boolean;

  constructor(private fb: FormBuilder, private router: Router) {
    this.burgerActive = false;
  }

  ngOnInit(): void {
  }


  burgerClick(): void {
    this.burgerActive = !this.burgerActive;
    // document.body.classList.add('lock');
    // document.body.classList.remove('lock');
    document.body.classList.toggle('lock');
    const arra = ['a', 'b', 'c'];
    let isA = arra.some(value => value.includes('a'));

  }
}
