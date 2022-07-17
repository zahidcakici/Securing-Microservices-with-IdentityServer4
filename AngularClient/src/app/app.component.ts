import {Component} from '@angular/core';
import {OidcSecurityService} from 'angular-auth-oidc-client';
import {HttpClient} from '@angular/common/http';
import {map, Observable, tap} from 'rxjs';
/**
 * @author Zahid Cakici <zahid.cakici@gmail.com>
 */
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(
    public oidcSecurityService: OidcSecurityService,
    private http: HttpClient
  ) {
  }

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe((auth) => {
      console.log('isAuthenticated', auth);
    });
  }

  login() {
    this.oidcSecurityService.authorize(
    );
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  callApi() {
    this.oidcSecurityService.getAccessToken().subscribe((token) => {
      console.log('token', token);
      this.http.get('https://localhost:5000/secretApi/weatherforecast', {
        headers: {Authorization: `Bearer ${token}`},
        responseType: 'text',
      }).subscribe((data) => {
          console.log('data', data);
        }
      );
    });
  }
}
