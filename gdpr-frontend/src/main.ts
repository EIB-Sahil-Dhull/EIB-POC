import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideStore, provideState } from '@ngrx/store';
import { userReducer } from './app/state/user.reducer';
import { provideHttpClient } from '@angular/common/http';
 

bootstrapApplication(AppComponent,{
  providers: [
    provideStore(),
    provideHttpClient(),
    provideState({ name: 'user', reducer: userReducer })
  ]},)
  .catch((err) => console.error(err));
