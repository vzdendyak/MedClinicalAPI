import {Component, OnInit} from '@angular/core';
import {DepartmentService} from '../../department-functionality/services/department.service';
import {Department} from '../../data/models/department';

@Component({
  selector: 'app-list-doctors',
  templateUrl: './list-doctors.component.html',
  styleUrls: ['./list-doctors.component.scss']
})
export class ListDoctorsComponent implements OnInit {
  showDoctors: boolean;
  departments: Department[];

  constructor(private departmentService: DepartmentService) {
    this.departmentService.getDepartments().subscribe(value => {
      this.departments = value;
      console.log(this.departments);
    });
  }

  ngOnInit(): void {
  }


  TitleMed(): void {
    let doctorsBlock = document.getElementById('doctors_block');
    let arrow = document.getElementById('arrow');
    if (doctorsBlock.style.height === '0px') {
      doctorsBlock.style.height = '500px';
      arrow.style.transform = 'rotate(90deg)';
    } else {
      doctorsBlock.style.height = '0px';
      arrow.style.transform = 'rotate(0deg)';
    }
    console.log(doctorsBlock);
  }

  toogleBlock(dep: Department) {
    console.log('debug');
    var depp = this.departments.find(dp => dp.id == dep.id);
    depp.isVisible = !depp.isVisible;

  }
}
