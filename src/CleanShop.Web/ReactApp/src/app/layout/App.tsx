import Header from './Header';
import { Container, CssBaseline, ThemeProvider, createTheme } from '@mui/material';
import { Outlet, ScrollRestoration } from 'react-router';
import { useAppSelector } from '../store/store';

function App() {
  const { darkMode } = useAppSelector((state) => state.ui);

  const paletteType = darkMode ? 'dark' : 'light';

  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea' : '#121212',
      },
    },
  });

  return (
    <ThemeProvider theme={theme}>
      <ScrollRestoration />
      <CssBaseline />
      <Header />
      <Container>
        <Outlet />
      </Container>
    </ThemeProvider>
  );
}

export default App;
