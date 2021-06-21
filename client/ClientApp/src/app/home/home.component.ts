import { Component, OnInit } from "@angular/core";
import { ConverterService } from "../converter/converter.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent implements OnInit {
  constructor(private converterService: ConverterService){}
  ngOnInit(): void {  }

}
