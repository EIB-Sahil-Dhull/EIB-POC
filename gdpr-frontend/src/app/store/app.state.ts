// src/app/store/app.state.ts

import { UserState } from "../state/user.state";


export interface AppState {
  user: UserState; 
}
