import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reversePipe',
})
export class ReversePipePipe implements PipeTransform {

  transform(value: string|null): string {
    return value ? value.split('').reverse().join('') : '';
  }

}
