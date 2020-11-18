import {Component, OnInit} from '@angular/core';
import {User} from '../../data/models/user';
import {Record} from '../../data/models/record';
import {AccountService} from '../services/account.service';
import {RecordService} from '../../department-functionality/services/record.service';

@Component({
  selector: 'app-my-records',
  templateUrl: './my-records.component.html',
  styleUrls: ['./my-records.component.scss']
})
export class MyRecordsComponent implements OnInit {
  user: User;
  records: Record[];
  expiredRecords: Record[];
  displayedColumns: string[] = ['doctor', 'patient', 'dateOfMeeting', 'dateOfRecord', 'service'];
  displayedColumns2: string[] = ['doctor', 'patient', 'dateOfMeeting', 'dateOfRecord', 'service', 'empty'];

  constructor(private accountService: AccountService, private recordService: RecordService) {
    const uId = localStorage.getItem('uId');
    this.accountService.getUser(uId).subscribe(value => {
      console.log('user got');
      this.user = value;
      this.records = value.records;
      this.expiredRecords = this.records.filter(rec => this.isDateExpired(rec.dateOfMeeting));
      this.records = this.records.filter(rec => !this.isDateExpired(rec.dateOfMeeting));
      if (this.user.departmentId) {
        this.displayedColumns.push('delete');
      }
      console.log(this.records);
    });
  }

  ngOnInit(): void {
  }

  deleteRecord(id: number): void {
    this.recordService.deleteRecord(id).subscribe(value => {
      console.log(value);
    });
  }

  isDateExpired(dateStr: any): boolean {
    const date = new Date(dateStr);
    const nowDate = new Date();
    if (date < nowDate) {
      return true;
    }
    return false;
  }
}
