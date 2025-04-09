import logo from './logo.svg';
import './App.css';
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import DadosDengue from './pages/DadosDengue';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<DadosDengue />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
