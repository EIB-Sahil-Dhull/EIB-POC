import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export  interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string; 
  address: string;     
  dateOfBirth: string; 
  createdDate: Date;
  consent: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5081/api/Users';
  
  constructor(private http: HttpClient) {}

  createUser(user: User): Observable<User> {
    
   user.dateOfBirth = new Date(user.dateOfBirth).toISOString();

    return this.http.post<User>(this.apiUrl, user);
  }

  getUsers(): Observable<User[]> {
  
    return this.http.get<User[]>(this.apiUrl);
    
  }
  
}
