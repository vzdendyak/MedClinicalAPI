import {Component, OnInit} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';
import {AuthService} from '../../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  burgerActive: boolean;
  isUserAuthenticated = false;

  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService) {
    this.burgerActive = false;
    this.isUserAuthenticated = this.authService.isUserAuthenticated();
  }

  ngOnInit(): void {

  }

  redirectTo(uri: string) {
    this.router.navigateByUrl('/account/cabinet', {skipLocationChange: true}).then(() =>
      this.router.navigate([uri]));
  }

  burgerClick(): void {
    this.burgerActive = !this.burgerActive;
    // document.body.classList.add('lock');
    // document.body.classList.remove('lock');
    document.body.classList.toggle('lock');
    const arra = ['a', 'b', 'c'];
    let isA = arra.some(value => value.includes('a'));

  }

  logOut() {
    this.authService.logOut();
    window.location.reload();

  }
}
