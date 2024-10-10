import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { userReducer } from './state/user.reducer';
import { UserEffects } from './state/user.effects';
import { UserService } from './services/user.service';
import { UserListComponent } from './user-list/user-list.component';
import { HttpClient } from '@angular/common/http';
import { AppState } from './store/app.state';

@NgModule({
  declarations: [UserListComponent],
  imports: [
    BrowserModule,
    StoreModule.forRoot({ user: userReducer }) ,
    EffectsModule.forRoot([UserEffects]),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: false,
    
    }),
    HttpClient
  ],
  providers: [UserService],
  bootstrap: [UserListComponent]
})
export class AppModule { }




