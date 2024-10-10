  import { createSelector } from '@ngrx/store';
  import { UserState } from './user.state';
  import { AppState } from '../store/app.state';

  export const selectUserState = (state: AppState) => state.user; 
  
  export const selectUsers = createSelector(
    selectUserState,
    (state: UserState) => state.users
  );

  export const selectLoading = createSelector(
    selectUserState,
    (state: UserState) => state.loading
  );

  export const selectError = createSelector(
    selectUserState,
    (state: UserState) => state.error
  );
