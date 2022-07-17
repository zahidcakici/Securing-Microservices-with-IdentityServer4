import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
/**
 * @author Zahid Cakici <zahid.cakici@gmail.com>
 */
@NgModule({
  declarations: [AppComponent],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    AuthModule.forRoot({
      config: {
        authority: 'https://localhost:5000/identity',
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: 'angular',
        scope: 'openid secretApi',
        responseType: 'code',
        logLevel: LogLevel.Debug,
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
