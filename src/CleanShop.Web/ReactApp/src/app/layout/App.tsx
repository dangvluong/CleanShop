import { useState } from "react";
import Catalog from "../../features/catalog/Catalog";
import Header from "./Header";
import {
  Container,
  CssBaseline,
  ThemeProvider,
  createTheme,
} from "@mui/material";

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? "dark" : "light";

  const theme = createTheme({
    palette: {
      mode: paletteType,
    },
  });

  function switchTheme(
    event: React.ChangeEvent<HTMLInputElement>,
    checked: boolean
  ) {
    setDarkMode(checked);
  }

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header switchTheme={switchTheme} />
      <Container>
        <Catalog />
      </Container>
    </ThemeProvider>
  );
}

export default App;
