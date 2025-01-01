import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-confirm',
  standalone: false,

  templateUrl: './confirm.component.html',
  styleUrl: './confirm.component.scss'
})
export class ConfirmComponent {
  @Input() confirmMessage:string ='';
  @Output() isConfirmed:EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(){
  }
  close(isConfirmed:boolean){
    this.isConfirmed.emit(isConfirmed);
  }
}
