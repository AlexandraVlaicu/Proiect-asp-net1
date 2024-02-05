import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app.routes';
import { BorderDirective } from './directives/border.directive';
import { HighlightDirective } from './directives/highlight.directive';
import { UpPipe } from './pipes/up.pipe';
import { TruncatePipe } from './pipes/truncate.pipe';

@NgModule({
  declarations: [HighlightDirective,BorderDirective,UpPipe,TruncatePipe],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
})
export class AppModule {}
