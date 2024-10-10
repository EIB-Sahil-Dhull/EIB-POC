import { createReducer, on } from '@ngrx/store';
import * as UserActions from './user.actions';
import { UserState, initialUserState } from './user.state';



export const userReducer = createReducer(
  initialUserState,
  on(UserActions.loadUsers, (state, { users }) => ({
    ...state,
    users,
    loading: false,
  })),
  on(UserActions.loadUsersSuccess, (state, { users }) => {
    console.log('Load Users Success action received:', users);
    return {
      ...state,
      loading: false,
      users
    };
  }),
  on(UserActions.loadUsersFailure, (state, { error }) => {
    console.log('Load Users Failure action received:', error);
    return {
      ...state,
      loading: false,
      error
    };
  }),
  on(UserActions.createUser, (state) => {
    console.log('Create User action dispatched');
    
    return {
      ...state,
      loading: true
    };
  }),
  on(UserActions.createUserSuccess, (state, { user }) => {
    console.log('Create User Success action received:', user);
    return {
      ...state,
      loading: false,
      users: [...state.users, user]
    };
  }),
  on(UserActions.createUserFailure, (state, { error }) => {
    console.log('Create User Failure action received:', error);
    return {
      ...state,
      loading: false,
      error
    };
  })
);
