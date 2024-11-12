import { createRoot } from 'react-dom/client'
// import './index.css'
import '../src/app/layout/styles.css'
import App from './app/layout/App.tsx'
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';


createRoot(document.getElementById('root')!).render(
    <App />
)
