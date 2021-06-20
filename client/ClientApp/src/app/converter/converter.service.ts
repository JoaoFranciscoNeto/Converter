import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {

  constructor(private httpClient: HttpClient) { }

  convert() {
    this.httpClient.get("https://localhost:5001/api/Converter?value=20&source=F&target=K").subscribe(response => {
        return response;
      },
      error => {
        console.log(error);
      });
  }
}
