import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { keyValue } from "../shared/Interfaces/keyValue.interface";
import { GlobalConstants } from "../common/global-constants";
import { user } from 'src/app/shared/Interfaces/user.interface';

 @Injectable({providedIn: 'root'})
 export class RegistrationService {
    constructor(private http: HttpClient) {}

      getAllCountries(): Observable<keyValue[]> {
         return this.http.get<keyValue[]>(GlobalConstants.apiURL + "/Registration/GetAllCountries")
      }

      getProvincesByCountryId(id: number): Observable<keyValue[]> {
         return this.http.get<keyValue[]>(GlobalConstants.apiURL + "/Registration/GetProvincesByCountryId",
         {params: new HttpParams().set('id', id)})
      }

      newUser(user: user): Observable<user> {
        return this.http.post<user>(GlobalConstants.apiURL + "/Registration/NewUser", user)
      }

    
 } 