import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(
      private router: Router
  ) { }

  ngOnInit() {
    
  }

  goToLogin() {
      this.router.navigate(['/main']);
  }

  goToClient() {
    this.router.navigate(['/client']).then();
  }

  goToTransaction() {
    this.router.navigate(['/transaction']).then();
  }

  goToAccountStatement() {
    this.router.navigate(['/account-statement']).then();
  }

  goToAccount() {
    this.router.navigate(['/account']).then();
  }

  goToLancamentos() {
    this.router.navigate(['/lancamentos']).then();
  }

  goToRelatorios() {
    this.router.navigate(['/relatorios']).then();
  }

}