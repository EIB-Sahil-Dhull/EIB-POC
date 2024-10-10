import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { UserService } from '../services/user.service';
import * as UserActions from './user.actions';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable()
export class UserEffects {
  constructor(private actions$: Actions, private userService: UserService) {}


  

  loadUsers$ = createEffect(() =>
  
    this.actions$.pipe(
      ofType(UserActions.loadUsers),
      mergeMap(() => {
        console.log('Load Users action dispatched'); 
        return this.userService.getUsers().pipe(
          map((users) => {
            console.log('Users retrieved successfully:', users); 
            return UserActions.loadUsersSuccess({ users });
          }),
          catchError((error) => {
            console.error('Error loading users:', error.message); 
            return of(UserActions.loadUsersFailure({ error: error.message }));
          })
        );
      })
    )
  );

  createUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.createUser),
      mergeMap(({ user }) =>
        this.userService.createUser(user).pipe(
          map((newUser) => UserActions.createUserSuccess({ user: newUser })),
          catchError((error) => of(UserActions.createUserFailure({ error: error.message })))
        )
      )
    )
  );
}
