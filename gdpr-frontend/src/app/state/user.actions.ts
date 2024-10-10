import { createAction, props } from '@ngrx/store';
import { User } from '../services/user.service';


export const loadUsers = createAction('[User] Load Users', props<{ users: User[] }>());
export const loadUsersSuccess = createAction('[User] Load Users Success', props<{ users: User[] }>());
export const loadUsersFailure = createAction('[User] Load Users Failure', props<{ error: string }>());


export const createUser = createAction('[User] Create User', props<{ user: User }>());
export const createUserSuccess = createAction('[User] Create User Success', props<{ user: User }>());
export const createUserFailure = createAction('[User] Create User Failure', props<{ error: string }>());
