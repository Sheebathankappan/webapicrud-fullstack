import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { CommonModule } from '@angular/common';
import { authInterceptor } from './core/interceptors/auth-interceptor';
import { provideHttpClient,withInterceptors } from '@angular/common/http';
import { routes } from './app.routes';



export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    CommonModule,
  provideHttpClient(withInterceptors([authInterceptor]))],
};
