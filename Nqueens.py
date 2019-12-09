#!/usr/bin/env python
# coding: utf-8

# In[3]:


from pulp import *
import sys
from PyQt5 import QtCore, QtWidgets
from PyQt5.QtWidgets import QMainWindow, QLabel, QGridLayout, QWidget
from PyQt5.QtCore import QSize, QRect
from PyQt5.QtGui import QPixmap


class QueensGrid:    
    def __init__(self,size):
        #Declare number of queens and board size. Create board.
        self.n = size
        self.Sequence = list(range(size))
        self.Rows = self.Sequence
        self.Cols = self.Sequence

        #Define the problem as a matrix of rows and cols which can have a value of 0 (no queen) or 1 (queen)
        self.prob = LpProblem("Choice", LpMaximize)
        self.board = LpVariable.dicts(name="board", indexs=(self.Rows,self.Cols),lowBound=0,upBound=1,cat=LpInteger)

        #Every row and every column must have one queen (no more, no less)
        for r in self.Rows:
            self.prob += lpSum([self.board[r][c] for c in self.Cols]) == 1,""

        for c in self.Cols:
            self.prob += lpSum([self.board[r][c] for r in self.Rows]) == 1,""

        #The diagonals are divided in four subdiagonals and specified separetely
        #Every diagonal can have either zero or one queen.

        for i in self.Cols:
            self.prob += lpSum([self.board[r][i-r] for r in range(i+1)]) <= 1,"" #Up-left diagonal
            self.prob += lpSum([self.board[r][i+r] for r in range(self.n-i)]) <= 1,"" #Up-right diagonal


        for i in range(self.n-1):
            self.prob += lpSum([self.board[r][self.n-r+i] for r in range(i+1, self.n)]) <= 1,"" #Bottom-right diagonal
            self.prob += lpSum([self.board[i+c+1][c] for c in range(self.n-i-1)]) <= 1,"" #Bottom-left diagonal    

        self.prob.solve()
    
    #Extract values of the obtained problem grid
    def grid(self):
        grid = [[0]*self.n for i in self.Rows]
        for r in self.Rows:
            for c in self.Cols:
                grid[r][c] = value(self.board[r][c])
        return grid
    
class HelloWindow(QMainWindow):
    def __init__(self,size,qg):
        QMainWindow.__init__(self)  
        self.size = size
        self.qg = qg

        # fix main window's size
        self.setMinimumSize(QSize(64*size, 64*size))
        self.setMaximumSize(QSize(64*size, 64*size))
        self.setWindowTitle("Queens")

        # create the central widget and attach it to the main window
        centralWidget = QWidget(self)
        self.setCentralWidget(centralWidget)

        # create a 8x8 layout, remove the spacing between the widgets 
        gridLayout = QGridLayout(self)
        gridLayout.setSpacing(0)
        centralWidget.setLayout(gridLayout)

        # populate the grid
        k = 0
        for i in range(size):
            for j in range(size):
            # create a small 64x64 pix label
                label = QLabel(self)
                label.setMinimumSize(64, 64)
                label.setMaximumSize(64, 64)

                # load either a white or grey background. (k+i) is a quick hack to get checkerboard pattern
                if(qg[i][j] == 1):
                    if ((k+i) % 2 == 0):
                        label.setPixmap(QPixmap('crownwhite.png'))
                    else:
                        label.setPixmap(QPixmap('crowngrey.png'))
                else:
                    if ((k+i) % 2 == 0):
                        label.setPixmap(QPixmap('white.png'))
                    else:
                        label.setPixmap(QPixmap('grey.png'))

                # add it to the layout 
                gridLayout.addWidget(label, i, j)
                k = k + 1

if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    qg = QueensGrid(4)
    mainWin = HelloWindow(4,qg.grid())
    mainWin.show()
    sys.exit( app.exec_() )

