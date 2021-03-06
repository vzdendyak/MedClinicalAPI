import {Component, OnInit} from '@angular/core';
import {AccountService} from '../../account/services/account.service';
import {User} from '../../data/models/user';
import {AuthService} from '../../auth/auth.service';

@Component({
  selector: 'app-cabinet-nav',
  templateUrl: './cabinet-nav.component.html',
  styleUrls: ['./cabinet-nav.component.scss']
})
export class CabinetNavComponent implements OnInit {
  user: User;

  constructor(private accountService: AccountService, public authService: AuthService) {
    const id = localStorage.getItem('uId');
    this.accountService.getShortUser(id).subscribe(value => {
      this.user = value;
    });
  }

  ngOnInit(): void {
  }

}
