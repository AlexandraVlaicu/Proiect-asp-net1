import { Directive, Input, ElementRef, Renderer2, HostListener } from '@angular/core';

@Directive({
  selector: '[appBorder]',
})
export class BorderDirective {
  @Input('appCustomBorder') borderColor: string = ''; 

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  @HostListener('mouseenter') onMouseEnter() {
    this.setBorder(this.borderColor || 'red');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.setBorder('');
  }

  private setBorder(color: string) {
    this.renderer.setStyle(this.el.nativeElement, 'border', `2px solid ${color}`);
  }
}
