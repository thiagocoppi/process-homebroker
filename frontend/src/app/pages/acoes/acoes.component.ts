import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acoes',
  templateUrl: './acoes.component.html',
  styleUrls: ['./acoes.component.css']
})
export class AcoesComponent implements OnInit {

  constructor() { }
  codigoAcao: string = "";
  ngOnInit(): void {
  }

}
