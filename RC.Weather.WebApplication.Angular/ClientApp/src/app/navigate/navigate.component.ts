import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-navigate',
  styleUrls: ['./navigate.component.css'],
  templateUrl: './navigate.component.html'
})
export class NavigateComponent {
  @Input() public text: string;
  @Input() public routes: string[];
}
