import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react-swc'

// https://vitejs.dev/config/
export default ({ mode }) => {
  // Load app-level env vars to node-level env vars.
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};
  const port = parseInt(process.env.VITE_FRONTEND_PORT as string) || 5173;

  return defineConfig({
    plugins: [react()],
    resolve: { alias: { '@': '/src' } },
    server: {
      port: port
    },
    preview: {
      port: port
      }
  });
}
