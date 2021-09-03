import { Inject, Injectable } from '@angular/core';
import { ContactModel } from '../models/contact.model';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ContactService {

  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getContact(id: number): Observable<ContactModel> {
    const endpointUrl = this._baseUrl + 'api/Contact?id=' + id;

    return this.http.get<ContactModel>(endpointUrl, this.getRequestHeaders()).pipe<ContactModel>(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public getContacts(): Observable<ContactModel[]> {
    const endpointUrl = this._baseUrl + 'api/Contact/Contacts';

    return this.http.get<ContactModel[]>(endpointUrl, this.getRequestHeaders()).pipe<ContactModel[]>(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public saveContact(newContact: ContactModel): Observable<boolean> {
    const endpointUrl = this._baseUrl + 'api/Contact';

    return this.http.post<boolean>(endpointUrl, newContact, this.getRequestHeaders()).pipe<boolean>(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public deleteContact(id: number): Observable<boolean> {
    const endpointUrl = this._baseUrl + 'api/Contact?id=' + id;

    return this.http.delete<boolean>(endpointUrl).pipe<boolean>(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public updateContact(contactToUpdate: ContactModel): Observable<boolean> {
    const endpointUrl = this._baseUrl + 'api/Contact';

    return this.http.put<boolean>(endpointUrl, contactToUpdate, this.getRequestHeaders()).pipe<boolean>(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  protected getRequestHeaders(): { headers: HttpHeaders | { [header: string]: string | string[]; } } {
    const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': `application/json, text/plain, */*`,
    });

    return { headers: headers };
  }
}
