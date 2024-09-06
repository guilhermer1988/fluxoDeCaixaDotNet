import { Component, OnInit } from '@angular/core';
import { LancamentoService } from '../../services/lancamento.service';
import { Lancamento } from '../../models/lancamento';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss']
})
export class LancamentoComponent implements OnInit {
  newTransaction: Lancamento = new Lancamento();
  successMessage: string | null = null; // Para armazenar a mensagem de sucesso

  constructor(private lancamentoService: LancamentoService) { }

  ngOnInit(): void {
  }

  createTransaction(): void {
    this.lancamentoService.createTransaction(this.newTransaction).subscribe(() => {
      this.successMessage = 'Lançamento criado com sucesso!'; // Mensagem de sucesso
      this.newTransaction = new Lancamento(); // Limpa o formulário após o sucesso
      setTimeout(() => this.successMessage = null, 5000); // Limpa a mensagem após 5 segundos
    });
  }

  formatCurrency(value: number): string {
    return value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  }
}
