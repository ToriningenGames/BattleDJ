   M S B A M L   `   `   `  ����D  @ScorpCamp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ScorpCamp	ScorpCamp  5   	       ScorpCamp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ScorpCamp     5   	     � Title$  Master's Mischief��5   	   $	��450��6#   $	��800��60    � 
ResizeMode$ NoResize=�6<   ��5	      �� 5
   
    �� ImageSource$ 
Sentry.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��320* �6   �� 5      $
��155* �6   �� 5      $
��320* �6   .+�5   
   �� -   5         ��Name$ PlayerNameLabel��5      $��Label��6)   $
��Left=�69   $	��Top=�6T    J� RenderTransformOrigin$ 1.555,2.166&�6l   $��0,70,0,0q�6�   $��26��6�   $	��309��6�   $��Center=�6�   ���	#BF23F7976�   �� 5   
   -   5        $ EnemyNameLabel��5      $��Label��6(   $��2��68   $
��Left=�6H   $��0,70,0,0q�6c   $	��Top=�6u   $ 0.336,-0.387&�6�   $��26��6�   $	��310��6�   $��Center=�6�   ���	#BF23F7976�   �� 5   
   -   5         ��Name$ PlayerImage��5      $��109.5,169,109.5,151q�6%   $ 0.5,0.5&�6B   z�5      V� 5      .~�5      ��  �� ScaleY$ 2Q�6%    �� ScaleX$ -2Q�60   �� 5      	 �� AngleY$	 0Q�6$   
 �� AngleX$
 0Q�6/   �� 5       �� Angle$ 0Q�6&   T� 5      5      5      �� 5   
   -   5        $ 
EnemyImage��5      $��2��6$   $��109.5,169,109.5,151q�64   $ 0.5,0.5&�6Q   z�5      V� 5       .~�5!      �� $ 2Q�6%   $ 2Q�60   �� 5"      �� 5#      T� 5$      5%      5'      �� 5(   
   -   5         ��Name$ PlayerSelectBack��5(      $	��<<<��6+   $
��Left=�6B   $��72.5,350,0,0q�6]   $	��Top=�6s   $��75��6�   $��19��6�    � ToolTip$ Previous Player��6�   �� 5)   
   -   5        $ PlayerSelectForward��5)      $	��>>>��6.   $��Right=�6E   $��0,350,72.5,0q�6a   $	��Top=�6w   $��75��6�   $��19��6�   $ Next Player��6�   �� 5*   
   -   5        $ EnemySelectBack��5*      $	��<<<��6*   $
��Left=�6A   $��72.5,350,0,0q�6\   $	��Top=�6r   $��75��6�   $��2��6�   $��19��6�   $ Previous Enemy��6�   �� 5+   
   -   5        $ EnemySelectForward��5+      $	��>>>��6-   $��Right=�6D   $��0,350,72.5,0q�6`   $	��Top=�6v   $��75��6�   $��2��6�   $��19��6�   $ 
Next Enemy��6�   �� 5,   
   -	   5        $ PlayGameButton��5,      $��Play!��6)   $��1��69   $
��Left=�6I   $��36.8,255,0,0q�6d   $	��Top=�6z   $��75��6�   6�   5.      5/      