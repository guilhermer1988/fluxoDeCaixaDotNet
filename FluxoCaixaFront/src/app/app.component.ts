import { Component, OnInit } from '@angular/core';
import { LancamentoService } from './services/lancamento.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(
    private lancamentoService: LancamentoService,
  ) {}
  ngOnInit(): void {
    //this.lancamentoService;
  }
}
