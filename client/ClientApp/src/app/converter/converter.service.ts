import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { UnitInfo } from "../../model/UnitInfo";

@Injectable({
  providedIn: 'root',
})
export class ConverterService {
  constructor(private httpClient: HttpClient) { }

  convert(fromUnit:string, toUnit:string, value:number): Observable<number> {
    return this.httpClient.get<number>(`https://localhost:5001/api/converter?value=${value}&source=${fromUnit}&target=${toUnit}`);
  }

  getAllQuantities() : Observable<string[]> {
    return this.httpClient.get<string[]>("https://localhost:5001/api/converter/quantities");
  }

  getAllUnitsForQuantity(quantity: string) : Observable<UnitInfo[]>{
    return this.httpClient.get<UnitInfo[]>(`https://localhost:5001/api/converter/units?quantity=${quantity}`);
  }
}
