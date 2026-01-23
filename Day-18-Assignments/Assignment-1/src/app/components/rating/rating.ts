import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-rating',
  imports: [CommonModule, FormsModule],
  templateUrl: './rating.html',
  styleUrl: './rating.css',
})
export class Rating {
  @Output() ratingSelected = new EventEmitter<number>();
  currentRating = 0;
  hoverRating = 0;
  selectRating(value: number) {
    this.currentRating = value;
    this.ratingSelected.emit(value);
  }
}