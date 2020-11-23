import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-list-doctors',
  templateUrl: './list-doctors.component.html',
  styleUrls: ['./list-doctors.component.scss']
})
export class ListDoctorsComponent implements OnInit {

  TitleMed(): void {
    let doctorsBlock = document.getElementById('doctors_block');
    let arrow = document.getElementById('arrow');
    if (doctorsBlock.style.height === '0px' || doctorsBlock.style.height == (0) {
      doctorsBlock.style.height = '500px';
      arrow.style.transform = 'rotate(90deg)';
    } else {
      doctorsBlock.style.height = '0px';
      arrow.style.transform = 'rotate(0deg)';
    }
    console.log(doctorsBlock);
  }
  constructor() {
  }

  ngOnInit(): void {
  }
}
