import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {

  constructor(private httpClient: HttpClient) { }


  convert(): void {
    this.httpClient.get("https://localhost:5001/api/converter?value=20&source=F&target=K").subscribe(response => {
        return response;
      },
      error => {
        console.log(error);
      });
  }

  getAllQuantities() : Observable<string[]> {
    return this.httpClient.get<string[]>("https://localhost:5001/api/converter/quantities");
  }

  getAllUnitsForQuantity(quantity: string) {
  }
}

export class Quantity {
  name: string;
}
