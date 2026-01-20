import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insurance-profiles',
  imports: [CommonModule],
  templateUrl: './insurance-profiles.html',
  styleUrls: ['./insurance-profiles.css'],
})
export class InsuranceProfiles {
  selectedIndex = 0;
  insuranceList = [
    {
      name: 'Auto',
      img: 'assets/auto.svg',
    },
    {
      name: 'Bundle & Save',
      img: 'assets/bundle.svg',  
    },
    {
      name: 'Home',
      img: 'assets/home.svg',
    },
    {
      name: 'Business',
      img: 'assets/business.svg',
    }
  ];
  selectCard(index: number) {
    this.selectedIndex = index;
  } 
}
