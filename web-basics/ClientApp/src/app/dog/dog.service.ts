import { Injectable } from '@angular/core';
import { Dog } from './dog';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/dog";

  get(): Observable<Dog[]> {
    return this.httpClient.get<Dog[]>(this.url);
  }

  addDog(dog: Dog) {
    return this.httpClient.post(this.url, dog);
  }

  addDog2(dog: Dog): Observable<Dog> {
    return this.httpClient.post<Dog>(this.url, dog);
  }
}
