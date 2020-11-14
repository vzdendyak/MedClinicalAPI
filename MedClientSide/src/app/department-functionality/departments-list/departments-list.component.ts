import {Component, OnInit} from '@angular/core';
import {Department} from '../../data/models/department';
import {DepartmentService} from '../services/department.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styleUrls: ['./departments-list.component.scss']
})
export class DepartmentsListComponent implements OnInit {
  departments: Department[];

  constructor(private departmentService: DepartmentService, private router: Router) {
    this.departmentService.getDepartments().subscribe(value => {
      this.departments = value;
    });
  }

  ngOnInit(): void {
  }

  goToDepartment(id: number): void {
    this.router.navigateByUrl(`/department/${id}`);
  }
}
