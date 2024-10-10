 // Assuming you have a User model defined somewhere.

import { User } from "../services/user.service";

export interface UserState {
  users: User[];
  loading: boolean;
  error: string | null;
}

export const initialUserState: UserState = {
  users: [], 
  loading: false,
  error: null
};
