import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/Person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl:string;
  apiUrl = 'api/person/';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.baseUrl = baseUrl;
  }

  getAll(): Observable<Person[]>{
    return this.http.get<Person[]>(this.baseUrl + this.apiUrl);
  }

  getPerson(id: string): Observable<Person>{
    return this.http.get<Person>(this.baseUrl + this.apiUrl + id);
  }

  post(person: Person): Observable<Person>{
    return this.http.post<Person>(this.baseUrl + this.apiUrl, person);
  }

  delete(id: string): Observable<Person>{
    return this.http.delete<Person>(this.baseUrl + this.apiUrl + id)
  }

  update(person: Person): Observable<Person>{
    return this.http.put<Person>(this.baseUrl + this.apiUrl, person);
  }
}
