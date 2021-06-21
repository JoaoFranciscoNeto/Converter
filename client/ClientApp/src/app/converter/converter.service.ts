import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {

  constructor(private httpClient: HttpClient) { }


  convert(fromUnit:string, toUnit:string, value:number): void {
    this.httpClient.get("https://localhost:5001/api/converter?value=${number}&source=${fromUnit}&target=${toUn}").subscribe(response => {
        return response;
      },
      error => {
        console.log(error);
      });
  }

  getAllQuantities() : Observable<string[]> {
    return this.httpClient.get<string[]>("https://localhost:5001/api/converter/quantities");
  }

  getAllUnitsForQuantity(quantity: string) : Observable<UnitInfo[]>{
    const path = `https://localhost:5001/api/converter/units?quantity=${quantity}`;
    console.log(path);
    return this.httpClient.get<UnitInfo[]>(path);
  }
}

export class UnitInfo {
  quantityName: string;
  name: string;
  symbol: string;
}
