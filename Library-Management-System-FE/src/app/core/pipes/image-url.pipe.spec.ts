import { ImageUrlPipe } from './image-url.pipe';

describe('ImageUrlPipe', () => {
  const pipe = new ImageUrlPipe();

  it('should create an instance', () => {
    expect(pipe).toBeTruthy();
  });

  it('should return empty string if no url provided', () => {
    expect(pipe.transform()).toBe('');
    expect(pipe.transform('')).toBe('');
  });

  it('should return original url if it starts with http', () => {
    const url = 'https://example.com/image.jpg';
    expect(pipe.transform(url)).toBe(url);
  });

  it('should prepend localhost if it is a local path', () => {
    const path = 'images/book1.jpg';
    expect(pipe.transform(path)).toBe(`https://localhost:7279/${path}`);
  });
});
