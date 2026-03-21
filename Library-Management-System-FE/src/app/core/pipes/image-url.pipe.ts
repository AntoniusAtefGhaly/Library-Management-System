import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'imageURL',
  standalone: true
})
export class ImageUrlPipe implements PipeTransform {
  transform(url?: string): string {
    if (!url) {
      return '';
    }
    if (url.startsWith('http')) {
      return url;
    }
    return `https://localhost:7279/${url}`;
  }
}
