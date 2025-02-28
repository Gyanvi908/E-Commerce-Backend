import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './app/layout/App.tsx'
import './app/layout/styles.css';
import reportWebVitals from './reportWebVitals'
import '../src/app/layout/styles.css'
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
//import { router } from './app/router/Routes.tsx';
//import { RouterProvider } from 'react-router-dom';
//import { RouterProvider } from 'react-router-dom';
//import { router } from './app/router/Routes';
//import React from 'react';
//import App from './app/layout/App';
//import { BrowserRouter } from 'react-router-dom';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
   <App />
   </React.StrictMode>
);
reportWebVitals();


function reportWebVitals() {
  throw new Error('Function not implemented.');
}
//<RouterProvider router={router} />
//</React.StrictMode>