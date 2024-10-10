import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as UserActions from '../state/user.actions';
import { UserState } from '../state/user.state';
import { User } from '../services/user.service';
import { selectError, selectLoading, selectUsers, selectUserState } from '../state/user.selectors';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../services/user.service'
import { AppState } from '../store/app.state';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-list',
  standalone: true,
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  imports: [NgIf, NgFor, FormsModule, CommonModule]
})
export class UserListComponent implements OnInit {

  users$: Observable<User[]>;
  loading$: Observable<boolean>;
  error$: Observable<string | null>;
  newUser: User = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    address: '',
    dateOfBirth: '',
    createdDate: new Date(),
    consent: false
  };
  isUserListVisible = true;
  isAddUserVisible = false;
  isGdprLinkClicked = false;
  today: string;


  constructor(private store: Store<AppState>, private userService: UserService) {
    this.users$ = this.store.select(selectUsers);
    this.loading$ = this.store.select(selectLoading);
    this.error$ = this.store.select(selectError);
    this.today = new Date().toISOString().split('T')[0];
  }

  ngOnInit(): void {
    console.log("abce");
    
    this.userService.getUsers().subscribe({
      next: (users_list) => {
        console.log('queryParams', users_list);
        
        
        if (users_list && users_list.length > 0) {
          this.store.dispatch(UserActions.loadUsers({ users: users_list }));
        } else {
          console.log('No users found, loadUsers action will not be dispatched');
        }
      }
    });
  }
  



  onSubmit(): void {
   
    if (!this.newUser.consent) {
      alert('Please provide consent to proceed.');
      return;
    }
  
    
    if (!this.newUser || Object.keys(this.newUser).length === 0) {
      alert('User data is missing. Please fill in the required fields.');
      return;
    }
  
   
    this.userService.createUser(this.newUser).subscribe({
      next: (new_user) => {
        console.log('queryParams', new_user);
        
  
        this.store.dispatch(UserActions.createUser({ user: this.newUser }));
        this.store.dispatch(UserActions.createUserSuccess({ user: this.newUser }));
        alert("User added successfully")
        this.showUserList();
        this.resetNewUser();
        location.reload()
      }
      
    });
    
  }
  

  showUserList(): void {
    this.isUserListVisible = true;
    this.isAddUserVisible = false;
  }



  showAddUserForm(): void {
    this.isUserListVisible = false;
    this.isAddUserVisible = true;
  }

  onGdprLinkClick(): void {
    this.isGdprLinkClicked = true;
  }

  onlyAllowNumbers(event: KeyboardEvent): void {
    const charCode = event.key.charCodeAt(0);
    if (charCode < 48 || charCode > 57) {
      event.preventDefault();
    }
  }

  preventTyping(event: KeyboardEvent): void {
    event.preventDefault();
  }

  trimEmail(): void {
    this.newUser.email = this.newUser.email.trim();
  }

  resetNewUser(): void {
        this.newUser = {
          id: '',
          firstName: '',
          lastName: '',
          email: '',
          phoneNumber: '',
          address: '',
          dateOfBirth: '', 
          createdDate: new Date(),
          consent: false
        };
      }
  
}
