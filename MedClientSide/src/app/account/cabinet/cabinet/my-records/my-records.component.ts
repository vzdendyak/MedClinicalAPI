import {Component, OnInit} from '@angular/core';
import {User} from '../../data/models/user';
import {Record} from '../../data/models/record';
import {AccountService} from '../services/account.service';

@Component({
  selector: 'app-my-records',
  templateUrl: './my-records.component.html',
  styleUrls: ['./my-records.component.scss']
})
export class MyRecordsComponent implements OnInit {
  user: User;
  records: Record[];
  displayedColumns: string[] = ['doctor', 'patient', 'dateOfMeeting', 'dateOfRecord', 'service'];

  constructor(private accountService: AccountService) {
    const uId = localStorage.getItem('uId');
    this.accountService.getUser(uId).subscribe(value => {
      console.log('user got');
      this.user = value;
      this.records = value.records;
      console.log(this.records);
    });
  }

  ngOnInit(): void {
  }

}
